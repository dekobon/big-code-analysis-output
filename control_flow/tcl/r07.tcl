proc chain {a} {
    if {$a == 1} { return 1 } elseif {$a == 2} { return 2 } else { return 0 }
}
proc nested {a} {
    if {$a == 1} { return 1 } else { if {$a == 2} { return 2 }; return 0 }
}
proc loops {xs} {
    for {set i 0} {$i < 3} {incr i} { }
    foreach x $xs { }
    while {1} { break }
    dict for {k v} $xs { }
}
proc sw {a} {
    switch -exact -- $a { 1 { return 1 } 2 - 3 { return 2 } default { return 0 } }
}
proc sw2 {a} { switch $a 1 { return 1 } default { return 0 } }
proc exc {} {
    catch { error "x" } msg
    try { throw MYERR "y" } on error {m o} { } finally { }
    ::return 1
    exit 2
    puts error
}
proc tern {a} { return [expr {$a > 0 ? $a : -$a}] }
