import logging
import sys
import asyncio

from services.bot_service import botPolling


async def main() -> None:

    logging.basicConfig(level=logging.INFO, stream=sys.stdout)
    await asyncio.gather(
        botPolling()
    )


if __name__ == "__main__":
    asyncio.run(main())
