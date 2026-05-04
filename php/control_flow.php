<?php

declare(strict_types=1);

namespace Acme\Synthetic;

function classify(int $score): string
{
    return match (true) {
        $score < 0 => 'invalid',
        $score === 0 => 'zero',
        $score < 50 => 'low',
        $score < 80 => 'medium',
        $score < 100 => 'high',
        $score === 100 => 'perfect',
        default => 'overflow',
    };
}

function summarize(?array $config, ?string $fallback): string
{
    $name = $config['name'] ?? $fallback ?? 'anonymous';
    $env = $config['env'] ?? 'dev';
    $debug = $config['debug'] ?? false;

    if ($debug):
        $output = "[$env] $name (debug)";
    else:
        $output = "[$env] $name";
    endif;

    return $output;
}

function describe(int $value, int $limit): string
{
    $tags = [];

    for ($i = 0; $i < $limit; $i++):
        if ($i === $value):
            $tags[] = "match-$i";
            continue;
        endif;
        if ($i % 2 === 0):
            $tags[] = "even-$i";
        else:
            $tags[] = "odd-$i";
        endif;
    endfor;

    return implode(',', $tags);
}

function searchTree(?object $node, string $key): mixed
{
    if ($node === null) {
        return null;
    }

    return $node->cache[$key]
        ?? $node->lookup?->find($key)
        ?? searchTree($node->parent ?? null, $key);
}

function categorizeBatch(iterable $items): array
{
    $buckets = ['short' => [], 'medium' => [], 'long' => []];

    foreach ($items as $item):
        $bucket = match (true) {
            strlen($item) < 4 => 'short',
            strlen($item) < 12 => 'medium',
            default => 'long',
        };
        $buckets[$bucket][] = $item;
    endforeach;

    return $buckets;
}

function loopUntil(callable $condition, int $maxAttempts): int
{
    $attempt = 0;

    while ($attempt < $maxAttempts):
        if ($condition($attempt)) {
            return $attempt;
        }
        $attempt++;
    endwhile;

    return -1;
}
