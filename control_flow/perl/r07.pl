sub chain { my $a = shift; if ($a == 1) { return 1 } elsif ($a == 2) { return 2 } else { return 0 } }
sub nested { my $a = shift; if ($a == 1) { return 1 } else { if ($a == 2) { return 2 } return 0 } }
sub unl { unless ($_[0]) { return 1 } else { return 0 } }
sub mods { my $a = shift; return 1 if $a; return 2 unless $a; $a++ while $a < 3; $a-- until $a < 1; print for 1..2; $a }
sub loops { for my $i (1..3) { } for (my $i = 0; $i < 3; $i++) { } foreach my $x (@_) { } while (1) { last } until (0) { next } OUTER: for (1) { for (1) { next OUTER } } }
sub sw { my $a = shift; print 6 when $a; }
sub exits { die "x"; exit 1; CORE::die "y"; CORE::exit 2; Carp::croak "z"; my %h = (die => 1, exit => 2); $obj->die; }
sub tern { $_[0] > 0 ? $_[0] : -$_[0] }
sub defined_or { my $a = shift // 0; $a //= 1; $a &&= 2; $a ||= 3; $a }
sub jump { goto DONE; DONE: }
