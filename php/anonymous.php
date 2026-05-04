<?php

declare(strict_types=1);

namespace Acme\Synthetic;

function makeMultiplier(int $factor): \Closure
{
    return function (int $value) use ($factor): int {
        return $value * $factor;
    };
}

function makeAdder(int $offset): callable
{
    return fn(int $value): int => $value + $offset;
}

function applyAll(array $values, callable $transform): array
{
    $out = [];
    foreach ($values as $value) {
        $out[] = $transform($value);
    }
    return $out;
}

function compose(callable ...$callables): \Closure
{
    return function (mixed $input) use ($callables): mixed {
        $result = $input;
        foreach ($callables as $callable) {
            $result = $callable($result);
        }
        return $result;
    };
}

function buildAnonymousCalculator(int $base): object
{
    return new class($base) {
        public function __construct(private readonly int $base) {}

        public function add(int $other): int
        {
            return $this->base + $other;
        }

        public function multiply(int $other): int
        {
            return $this->base * $other;
        }

        public function summarize(array $values): array
        {
            $sum = array_reduce($values, fn(int $a, int $b): int => $a + $b, 0);
            $product = array_reduce(
                $values,
                function (int $acc, int $value): int {
                    return $acc * $value;
                },
                1,
            );
            return ['sum' => $sum, 'product' => $product];
        }
    };
}

function partitionBy(array $values, callable $predicate): array
{
    $matched = [];
    $rest = [];
    foreach ($values as $value) {
        if ($predicate($value)) {
            $matched[] = $value;
        } else {
            $rest[] = $value;
        }
    }
    return [$matched, $rest];
}
