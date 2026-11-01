defmodule M do
  def f(a) do
    if a, do: throw(:x), else: raise("y")
    unless a do
      reraise("z", [])
    end
    for x <- [1], do: exit(:n)
    while a do
      g()
    end
    case a do
      1 -> :a
      _ -> :b
    end
    cond do
      a -> :a
      true -> :b
    end
    with {:ok, v} <- g() do
      v
    end
    try do
      g()
    rescue
      e -> e
    catch
      :throw, v -> v
    end
    receive do
      m -> m
    after
      0 -> :t
    end
    Kernel.exit(:remote)
    M.throw(:remote)
    quote do
      if unquote(a), do: 1
    end
  end
end
