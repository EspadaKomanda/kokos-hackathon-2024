import logging
import sys
import asyncio

from Services.botService import botPolling
from Database.database import Database


async def main() -> None:

    logging.basicConfig(level=logging.INFO, stream=sys.stdout)

    async with Database():
        pass

    await asyncio.gather(
        botPolling()
    )


if __name__ == "__main__":
    asyncio.run(main())
