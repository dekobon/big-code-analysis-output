class S {
    int subjTernary(int a, boolean b) { switch (b ? a : 0) { case 1: return 1; default: return 0 } }
    int subjClosure(int a) { switch ({ x -> x > 0 ? x : -x }(a)) { case 1: return 1; default: return 0 } }
    int armNested(int a) { switch (a) { case 1: if (a > 0) { return 1 }; return 2; default: return 0 } }
    int exprArm(int a) { return switch (a) { case 1 -> a > 0 ? 1 : 2; default -> { if (a < 0) { yield 3 }; yield 0 } } }
    void empty(int a) { switch (a) { } }
    int nestedSwitch(int a, int b) { switch (a) { case 1: switch (b) { case 2: return 2; default: return 0 }; default: return 0 } }
}
