<?php
function chain($a) { if ($a == 1) { return 1; } elseif ($a == 2) { return 2; } else if ($a == 3) { return 3; } else { return 0; } }
function nested($a) { if ($a == 1) { return 1; } else { if ($a == 2) { return 2; } return 0; } }
function alt($a) { if ($a == 1): return 1; elseif ($a == 2): return 2; else: return 0; endif; }
function loops($xs) { for ($i = 0; $i < 3; $i++) { } foreach ($xs as $x) { } while (true) { break; } do { } while (false); }
function sw($a) { switch ($a) { case 1: return 1; case 2: case 3: return 2; default: return 0; } }
function mt($a) { return match ($a) { 1 => 1, 2, 3 => 2, default => 0 }; }
function exc() { try { throw new Exception(); } catch (RuntimeException | LogicException $e) { } catch (Exception $e) { } finally { } }
function tern($a) { return $a > 0 ? $a : -$a; }
function nc($a) { $b = $a ?? 0; $b ??= 1; return $b; }
function gen() { yield 1; yield from [2]; }
function ex() { exit(1); die("x"); }
function te($s) { return $s ?? throw new Exception(); }
function jump() { goto done; done: }
