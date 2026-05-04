<?php

declare(strict_types=1);

namespace Acme\Synthetic;

function renderEmail(string $name, string $product, float $total): string
{
    $heading = strtoupper($product);

    return <<<EMAIL
Hello $name,

Thank you for purchasing {$heading}.
Your total today was \${$total}.

We hope you enjoy it!

-- The {$product} team
EMAIL;
}

function renderTemplate(string $title, array $bullets): string
{
    $body = '';
    foreach ($bullets as $idx => $bullet) {
        $position = $idx + 1;
        $body .= "  $position. $bullet\n";
    }

    return <<<TEMPLATE
=== $title ===
$body
=== end ===
TEMPLATE;
}

function rawSqlExample(string $table): string
{
    return <<<'SQL'
SELECT *
FROM {$placeholder}
WHERE deleted_at IS NULL
  AND created_at > NOW() - INTERVAL '7 days'
ORDER BY id DESC
SQL;
}

function literalShellSnippet(): string
{
    return <<<'BASH'
#!/usr/bin/env bash
set -euo pipefail

for f in *.txt; do
    echo "Processing $f"
    grep -E '^(error|warn):' "$f" || true
done
BASH;
}

function describeDocument(string $author, int $year): string
{
    $citation = <<<CITE
$author, "Synthetic Corpus", $year.
CITE;

    return sprintf("Cited as: %s", $citation);
}

function multilineCsv(array $rows): string
{
    $out = '';
    foreach ($rows as $row) {
        $cols = array_map(
            static fn(mixed $v): string => is_string($v) ? "\"$v\"" : (string) $v,
            $row,
        );
        $out .= implode(',', $cols) . "\n";
    }
    return $out;
}
