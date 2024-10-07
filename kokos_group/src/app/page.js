import Header from "../components/header_component.js";
import Store from "../components/store_component.js";


export default function Home() {
  return (
    <>
      <Header />
      <main className="container">
        <Store/>
      </main>
    </>
  );
}
