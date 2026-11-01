proc f {a} {
    if {$a eq "x"} { return 1 } elseif {$a eq "y"} { return 2 } else { if {1} { error "e" } }
    for {set i 0} {$i < 3} {incr i} { }
    foreach x [list a b] { }
    while {1} { break }
    switch -glob -- $a { "x*" { return 3 } default { } }
    switch $a "x" { throw E m }
    catch { error "y" } msg
    try { exit 1 } on error {m o} { } finally { }
    try { puts error } finally { }
    ::return
}
