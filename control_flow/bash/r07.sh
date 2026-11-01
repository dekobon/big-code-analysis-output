chain() {
  if [ "$1" = 1 ]; then return 1; elif [ "$1" = 2 ]; then return 2; else return 0; fi
}
nested() {
  if [ "$1" = 1 ]; then return 1; else if [ "$1" = 2 ]; then return 2; fi; return 0; fi
}
loops() {
  for x in a b; do :; done
  for ((i = 0; i < 3; i++)); do :; done
  while true; do break; done
  until false; do break; done
  select x in a b; do break; done
}
sw() { case "$1" in 1) return 1 ;; 2 | 3) return 2 ;; *) return 0 ;; esac; }
ex() { exit 1; }
notex() { echo exit; }
