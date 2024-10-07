"use client"
import Link from "next/link";
import Image from "next/image";
import { usePathname } from "next/navigation";
import * as img from "../assets/images.js";
import "../styles/header.css";

export default function Header() {
    const pathname = usePathname();

    return (
        <header className="bg-primary">
            <ul className="flex justify-evenly text-white text-3xl items-center">
                <li>
                    <Link href="/">
                        <Image src={img.logo} height={100} />
                    </Link>
                </li>
                <li>
                    <Link href="/news" className={pathname === "/news" ? "active" : ""}>
                        Новости
                    </Link>
                </li>
                <li>
                    <Link href="/team" className={pathname === "/team" ? "active" : ""}>
                        Команда
                    </Link>
                </li>
                <li>
                    <Link href="/matches" className={pathname === "/matches" ? "active" : ""}>
                        Матчи
                    </Link>
                </li>
                <li>
                    <Link href="/shop" className={pathname === "/shop" ? "active" : ""}>
                        Магазин
                    </Link>
                </li>
                <li>
                    <Link href="/about" className={pathname === "/about" ? "active" : ""}>
                        О клубе
                    </Link>
                </li>
                <li>
                    <Link href="/contacts" className={pathname === "/contacts" ? "active" : ""}>
                        Контакты
                    </Link>
                </li>
                <li>
                    <Link href="/profile" className={pathname === "/profile" ? "active" : ""}>
                        Профиль
                    </Link>
                </li>
            </ul>
        </header>
    );
}
