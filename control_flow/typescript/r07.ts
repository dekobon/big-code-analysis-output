function chain(a) { if (a === 1) { return 1; } else if (a === 2) { return 2; } else { return 0; } }
function nested(a) { if (a === 1) { return 1; } else { if (a === 2) { return 2; } return 0; } }
function loops(xs) {
  for (let i = 0; i < 3; i++) { }
  for (const x of xs) { }
  for (const k in xs) { }
  while (true) { break; }
  do { } while (false);
  outer: for (;;) { for (;;) { continue outer; } }
}
function sw(a) { switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0; } }
function exc() { try { throw new Error("x"); } catch (e) { } finally { } }
function exc2() { try { } catch { } }
function tern(a) { return a > 0 ? a : -a; }
function nullish(a) { let b = a ?? 0; b ??= 1; b ||= 2; b &&= 3; return a?.x; }
function* gen() { yield 1; yield* [2]; }
const arrow = (a) => { if (a) { return 1; } return 0; };
class K { static { if (true) { } } }
function typed(a: number): number { if (a > 0) { return a; } else { return -a; } }
