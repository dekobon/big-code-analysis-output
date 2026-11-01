fun chain(a: Int): Int {
    if (a == 1) { return 1 } else if (a == 2) { return 2 } else { return 0 }
}
fun nested(a: Int): Int {
    if (a == 1) { return 1 } else { if (a == 2) { return 2 }; return 0 }
}
fun loops(xs: List<Int>) {
    for (x in xs) { }
    while (xs.isEmpty()) { break }
    do { } while (false)
    outer@ for (x in xs) { for (y in xs) { continue@outer } }
}
fun sw(a: Int): Int = when (a) { 1 -> 1; 2, 3 -> 2; else -> 0 }
fun swb(a: Int): Int = when { a > 0 -> 1; else -> 0 }
fun exc() { try { throw RuntimeException() } catch (e: RuntimeException) { } finally { } }
fun ifexpr(a: Int): Int = if (a > 0) a else -a
fun safe(a: String?): Int = a?.length ?: 0
