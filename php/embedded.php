<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Embedded PHP Example</title>
</head>
<body>
<?php

declare(strict_types=1);

$pageTitle = 'Synthetic Corpus';
$items = [
    ['name' => 'alpha', 'count' => 1],
    ['name' => 'beta', 'count' => 2],
    ['name' => 'gamma', 'count' => 3],
];

function renderItemRow(array $item): string
{
    $name = htmlspecialchars($item['name']);
    $count = (int) $item['count'];
    $emphasis = $count > 1 ? '<strong>' . $count . '</strong>' : (string) $count;
    return "<tr><td>$name</td><td>$emphasis</td></tr>";
}

?>
    <h1><?= htmlspecialchars($pageTitle) ?></h1>

<?php if (count($items) > 0): ?>
    <table>
        <thead>
            <tr><th>Name</th><th>Count</th></tr>
        </thead>
        <tbody>
        <?php foreach ($items as $item): ?>
            <?= renderItemRow($item) ?>
        <?php endforeach; ?>
        </tbody>
    </table>
<?php else: ?>
    <p>No items.</p>
<?php endif; ?>

<?php
$total = array_sum(array_column($items, 'count'));

if ($total > 5) {
    echo "<p>Total exceeds threshold: $total</p>";
} elseif ($total > 0) {
    echo "<p>Total: $total</p>";
} else {
    echo "<p>No data.</p>";
}
?>
</body>
</html>
