from enum import Enum


class OrderType(Enum):
    BUY = 0
    SELL = 1
    BUY_LIMIT = 2
    SELL_LIMIT = 3
    BUY_STOP = 4
    SELL_STOP = 5
    BALANCE = 6
    CREDIT = 7


def order_type(t):
    if t < OrderType.BUY_LIMIT.value:
        return 'market'
    else:
        return 'limit'


def order_side(t):
    if t == OrderType.BUY.value or t == OrderType.BUY_LIMIT.value or t == OrderType.BUY_STOP.value:
        return 'buy'
    return 'sell'


def taker_maker(t):
    if t == OrderType.BUY.value or t == OrderType.BUY_LIMIT.value or t == OrderType.BUY_STOP.value:
        return 'taker'
    return 'maker'


class OrderStatus(Enum):
    OPEN = 0  # order open, used for opening orders
    PENDING = 1  # order pending, only used in the streaming getTrades command
    CLOSE = 2  # order close
    MODIFY = 3  # order modify, only used in the tradeTransaction command
    DELETE = 4  # order delete, only used in the tradeTransaction command


class TransactionStatus(Enum):
    ERROR = 0  # error
    PENDING = 1  # pending
    ACCEPTED = 3  # The transaction has been executed successfully
    REJECTED = 4  # The transaction has been rejected


class QuoteId(Enum):
    FIXED = 1
    FLOAT = 2
    DEPTH = 3
    CROSS = 4


class ProfitMode(Enum):
    FOREX = 5
    CFD = 6


class MarginMode(Enum):
    FOREX = 101
    CFD_LEVERAGED = 102
    CFD = 103


class PriceLevel(Enum):
    ALL = -1
    BASE = 0


class Weekday(Enum):
    MONDAY = 1
    TUESDAY = 2
    WEDNESDAY = 3
    THURSDAY = 4
    FRIDAY = 5
    SATURDAY = 6
    SUNDAY = 7
