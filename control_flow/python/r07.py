def chain(a):
    if a == 1:
        return 1
    elif a == 2:
        return 2
    else:
        return 0

def sole_if(a):
    if a == 1:
        return 1
    else:
        if a == 2:
            return 2

def nested(a):
    if a == 1:
        return 1
    else:
        x = 0
        if a == 2:
            return 2
        return x

def loops(xs):
    for x in xs:
        pass
    else:
        pass
    while False:
        break
    else:
        pass
    async def g():
        async for y in xs:
            pass
        async with xs:
            pass
    return [x for x in xs if x], {x: x for x in xs}, {x for x in xs}, (x for x in xs if x)

def sw(a):
    match a:
        case 1:
            return 1
        case 2 | 3:
            return 2
        case _ if a > 0:
            return 3
        case _:
            return 0

def exc():
    try:
        raise ValueError("x")
    except ValueError as e:
        pass
    except (TypeError, KeyError):
        pass
    else:
        pass
    finally:
        pass

def tern(a):
    return a if a > 0 else -a

def gen():
    yield 1
    x = yield
    yield from [2]

def asserts(a):
    assert a > 0
