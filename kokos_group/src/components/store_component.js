import Link from "next/link";

export default function Store() {
    return (
        <div className="">
            <h3 className="inline-block mr-5 text-3xl">Магазин</h3>
            <span> <Link href="/shop">Перейти в магазин ➞</Link></span>
            <div className="grid grid-cols-4 gap-5">
                <div className="p-2 text-primary">
                    <img src="https://via.placeholder.com/250x250" />
                    <p className="float-end text-primary text-4xl">➜</p>
                </div>
                <div className="p-2 text-primary">
                    
                    <img src="https://via.placeholder.com/250x250" />
                    <p className="float-end text-primary text-4xl">➜</p>
                </div>
                <div className="p-2">
                    
                    <img src="https://via.placeholder.com/250x250" />
                    <p className="float-end text-primary text-4xl">➜</p>
                </div>
                <div className="p-2">
                    
                    <img src="https://via.placeholder.com/250x250" />
                    <p className="float-end text-primary text-4xl">➜</p>
                </div>
            </div>
        </div>
    )
}