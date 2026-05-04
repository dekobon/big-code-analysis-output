<?php

declare(strict_types=1);

namespace Acme\Synthetic;

interface Greetable
{
    public function greet(string $name): string;

    public function farewell(string $name): string;
}

abstract class Greeter implements Greetable
{
    public function __construct(
        protected readonly string $prefix,
        protected readonly string $suffix = '!',
    ) {}

    public function farewell(string $name): string
    {
        return sprintf('%s %s%s', 'Goodbye', $name, $this->suffix);
    }

    abstract public function greet(string $name): string;
}

final class FormalGreeter extends Greeter
{
    private int $callCount = 0;

    public function greet(string $name): string
    {
        $this->callCount++;
        return sprintf('%s %s%s', $this->prefix, $name, $this->suffix);
    }

    public function callCount(): int
    {
        return $this->callCount;
    }
}

final class CasualGreeter extends Greeter
{
    public function greet(string $name): string
    {
        if ($name === '') {
            return 'Hey there!';
        }

        return "Hey $name{$this->suffix}";
    }
}

final class GreeterRegistry
{
    /** @var array<string, Greetable> */
    private array $registry = [];

    public function register(string $key, Greetable $greeter): void
    {
        $this->registry[$key] = $greeter;
    }

    public function get(string $key): ?Greetable
    {
        return $this->registry[$key] ?? null;
    }

    public function dispatch(string $key, string $name): string
    {
        $greeter = $this->get($key);
        if ($greeter === null) {
            throw new \RuntimeException("No greeter for key: $key");
        }

        return $greeter->greet($name);
    }
}
