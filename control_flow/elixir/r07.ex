defmodule M do
  def branch(a) do
    if a == 1 do 1 else 0 end
    if(a == 2, do: 1, else: 2)
    unless a do 1 else 0 end
  end
  def sw(a) do
    case a do 1 -> 1; 2 -> 2; _ -> 0 end
    cond do a > 0 -> 1; true -> 0 end
    with {:ok, x} <- f(a), {:ok, y} <- g(x) do y else _ -> 0 end
    with {:ok, x} <- f(a), do: x
    receive do {:m, v} -> v after 100 -> 0 end
    receive do after 100 -> 0 end
  end
  def loops(xs) do
    for x <- xs, x > 0, do: x
    for <<c <- "abc">>, do: c
  end
  def exc(a) do
    try do f(a) rescue e in RuntimeError -> e catch :throw, v -> v else v -> v after :ok end
    try(do: f(a), rescue: (e -> e))
    foo do g() rescue e -> e end
    foo(do: g(), rescue: (e -> e))
    Foo.bar(a) do 1 else 2 end
    Foo.bar(a, do: 1, else: 2)
    raise "x"
    throw :y
    exit(:z)
    reraise "w", []
  end
  def guard(a) when is_integer(a) and a > 0, do: a
  def anon, do: fn x when x > 0 -> x; _ -> 0 end
  def short(a, b), do: a && b || a and b or Kernel.||(a, b)
end
defmodule Sections do
  def with_kw(a) do
    with({:ok, x} <- f(a), do: x, else: (_ -> 0))
    with {:ok, x} <- f(a) do x else _ -> 0 end
  end
  def bracketed(a) do
    if(a, [do: 1, else: 2])
    try([do: f(a), rescue: (e -> e)])
    foo(a, [do: 1, else: 2])
  end
  def no_do(a) do
    foo(a, else: 2)
    foo(a, rescue: (e -> e))
    foo(else: 2, do: 1)
  end
  def nested_lists(a) do
    foo(a, [[do: 1, else: 2]])
    foo([do: 1], else: 2)
    foo(%{do: 1, else: 2})
    bar(foo(do: 1, else: 2), do: 3)
  end
  def remote(a) do
    Foo.bar(a, do: 1, else: 2)
    Foo.bar(a, do: 1, rescue: (e -> e))
    Foo.bar(a) do 1 rescue e -> e end
  end
end
