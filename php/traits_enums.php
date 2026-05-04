<?php

declare(strict_types=1);

namespace Acme\Synthetic;

trait LoggerAware
{
    private ?\Closure $logger = null;

    public function setLogger(callable $logger): void
    {
        $this->logger = \Closure::fromCallable($logger);
    }

    protected function log(string $level, string $message): void
    {
        if ($this->logger !== null) {
            ($this->logger)($level, $message);
        }
    }
}

trait Counts
{
    private int $count = 0;

    public function increment(int $by = 1): int
    {
        $this->count += $by;
        return $this->count;
    }

    public function reset(): void
    {
        $this->count = 0;
    }
}

enum Severity: int
{
    case Debug = 0;
    case Info = 1;
    case Warning = 2;
    case Error = 3;

    public function label(): string
    {
        return match ($this) {
            Severity::Debug => 'debug',
            Severity::Info => 'info',
            Severity::Warning => 'warning',
            Severity::Error => 'error',
        };
    }

    public static function fromLabel(string $label): self
    {
        return match (strtolower($label)) {
            'debug' => self::Debug,
            'info' => self::Info,
            'warning', 'warn' => self::Warning,
            'error', 'err' => self::Error,
            default => throw new \ValueError("Unknown severity: $label"),
        };
    }
}

enum Status
{
    case Active;
    case Inactive;
    case Pending;

    public function isTerminal(): bool
    {
        return $this !== Status::Pending;
    }
}

final class EventBus
{
    use LoggerAware;
    use Counts;

    public function publish(Severity $severity, string $event): void
    {
        $this->increment();
        $this->log($severity->label(), $event);
    }
}
