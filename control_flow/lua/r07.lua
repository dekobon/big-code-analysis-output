local function chain(a)
  if a == 1 then return 1 elseif a == 2 then return 2 else return 0 end
end
local function nested(a)
  if a == 1 then return 1 else if a == 2 then return 2 end return 0 end
end
local function loops(xs)
  for i = 1, 3 do end
  for k, v in pairs(xs) do end
  while true do break end
  repeat until true
  goto done
  ::done::
end
local function exits() error("x") os.exit(1) myError() return 1 end
