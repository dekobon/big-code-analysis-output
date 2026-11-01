fn chain(a: i32) -> i32 {
    if a == 1 { 1 } else if a == 2 { 2 } else { 0 }
}
fn nested(a: i32) -> i32 {
    if a == 1 { 1 } else { if a == 2 { return 2; } 0 }
}
fn iflet(o: Option<i32>) -> i32 { if let Some(v) = o { v } else { 0 } }
fn letelse(o: Option<i32>) -> i32 { let Some(v) = o else { return 0 }; v }
fn loops(xs: &[i32]) {
    for _x in xs { }
    while false { break; }
    loop { break; }
    'outer: loop { loop { continue 'outer; } }
    while let Some(_) = xs.first() { break; }
}
fn sw(a: i32) -> i32 { match a { 1 => 1, 2 | 3 => 2, n if n > 0 => 3, _ => 0 } }
fn exits(r: Result<i32, ()>) -> Result<i32, ()> { let v = r?; return Ok(v); }
fn tern(a: i32) -> i32 { if a > 0 { a } else { -a } }
trait T {}
struct S;
impl T for S {}
fn hrtb<F: for<'a> Fn(&'a u8)>(_: F) {}
fn wherebound<F>(_: F) where F: for<'a> Fn(&'a u8) {}
type P = for<'a> fn(&'a u8);
fn fnptr(_: for<'a> fn(&'a u8)) {}
fn mac() { m!(for x in xs {} while c {} if c {} loop {}); }
fn closure_in_if(a: i32) { if a > 0 { let f = |x: i32| if x > 0 { x } else { 0 }; f(a); } }
#[cfg(test)]
mod tests {
    trait U {}
    struct V;
    impl U for V {}
    fn tf<F: for<'a> Fn(&'a u8)>(_: F) -> Result<(), ()> { let _ = Ok::<(), ()>(())?; Ok(()) }
}
fn with_try_and_type_for<F: for<'a> Fn(&'a u8)>(f: F, r: Result<u8, ()>) -> Result<u8, ()> { let v = r?; f(&v); Ok(v) }
