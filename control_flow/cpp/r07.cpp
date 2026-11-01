#include <vector>
int chain(int a) {
    if (a == 1) { return 1; } else if (a == 2) { return 2; } else { return 0; }
}
int nested(int a) {
    if (a == 1) { return 1; } else { if (a == 2) { return 2; } return 0; }
}
template <typename T> int cx(T t) { if constexpr (sizeof(T) > 1) { return 1; } else { return 0; } }
int initif(std::vector<int> v) { if (auto n = v.size(); n > 0) { return 1; } return 0; }
void loops(std::vector<int> v) {
    for (int i = 0; i < 3; i++) { }
    for (auto x : v) { }
    while (v.empty()) { break; }
    do { } while (false);
    goto done;
done: ;
}
int sw(int a) { switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0; } }
void exc() { try { throw 1; } catch (int e) { } catch (...) { } }
int tern(int a) { return a > 0 ? a : -a; }
auto lam(int a) { return [a](int b) { if (b > a) { return b; } return a; }; }
template <typename T> requires (sizeof(T) > 1 && sizeof(T) < 8) int req(T) { if (true) { return 1; } return 0; }
struct Co { struct promise_type; };
