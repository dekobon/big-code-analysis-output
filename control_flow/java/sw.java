class S {
    int subjTernary(int a, boolean b) { switch (b ? a : 0) { case 1: return 1; default: return 0; } }
    int subjLambda(java.util.function.IntUnaryOperator f) { switch (f.applyAsInt(1)) { case 1: return 1; default: return 0; } }
    int subjLambdaBody(int a) { switch (((java.util.function.IntUnaryOperator) x -> x > 0 ? x : -x).applyAsInt(a)) { case 1: return 1; default: return 0; } }
    int armNested(int a) { switch (a) { case 1: if (a > 0) { return 1; } return 2; default: return 0; } }
    int exprArm(int a) { return switch (a) { case 1 -> a > 0 ? 1 : 2; default -> { if (a < 0) { yield 3; } yield 0; } }; }
    void empty(int a) { switch (a) { } }
    int guarded(Object o) { return switch (o) { case Integer i when i > 0 && i < 9 -> 1; default -> 0; }; }
    int nestedSwitch(int a, int b) { switch (a) { case 1: switch (b) { case 2: return 2; default: return 0; } default: return 0; } }
}
