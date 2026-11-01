int chain(int a) {
    if (a == 1) { return 1; } else if (a == 2) { return 2; } else { return 0; }
}
int nested(int a) {
    if (a == 1) { return 1; } else { if (a == 2) { return 2; } return 0; }
}
void loops(int n) {
    for (int i = 0; i < n; i++) { }
    while (n) { break; }
    do { } while (0);
    goto done;
done: ;
}
int sw(int a) { switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0; } }
int tern(int a) { return a > 0 ? a : -a; }
int bare_if(int x) { if (x) return 1; return 0; }
