
export default function LiveStream() {
    return (
        <div className="flex justify-center items-center h-screen">
            <iframe
                width="560"
                height="315"
                //TODO: Заменить CHANNEL_ID на ID канала
                src="https://www.youtube.com/embed/CHANNEL_ID"
                title="YouTube Live Stream"
                allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                allowFullScreen
            ></iframe>
        </div>
    );
}
