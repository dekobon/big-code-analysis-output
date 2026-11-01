def chain(a)
  if a == 1 then 1 elsif a == 2 then 2 else 0 end
end
def nested(a)
  if a == 1 then 1 else (if a == 2 then 2 end; 0) end
end
def unl(a) unless a then 1 else 0 end end
def mods(a)
  return 1 if a
  return 2 unless a
  a += 1 while a < 3
  a -= 1 until a < 1
  a
end
def loops(xs)
  for x in xs do end
  while true do break end
  until false do redo if false; break end
  xs.each { |x| retry if false }
end
def sw(a)
  case a when 1 then 1 when 2, 3 then 2 else 0 end
end
def swm(a)
  case a
  in Integer => n if n > 0
    1
  in [x, *]
    2
  else
    0
  end
end
def exc
  begin; raise "x"; rescue ArgumentError => e; rescue => e; else; ensure; end
  x = (raise "y" rescue 0)
  exit 1
  Kernel.exit 2
  Kernel.raise "z"
  obj.exit
  exit!
end
def tern(a) a > 0 ? a : -a end
def safe(a) a&.b end
