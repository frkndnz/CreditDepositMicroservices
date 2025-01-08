import React from "react";
import Navbar from "../Navbar/Navbar";
import Footer from "../Footer/Footer";

function Layout({ children }) {
    return (
        <div style={styles.container}>
            <header>
                <Navbar />
            </header>

            <main style={styles.main}>
                {children} {/* children prop'unu kullanarak sayfa içeriğini buraya ekleyeceğiz */}
            </main>
            <footer>
                <Footer />
            </footer>
        </div>
    );
}

const styles = {
    container: {
      minHeight: '100vh',
      display: 'flex',
      flexDirection: 'column'
    },
    main: {
      flex: 1,
      width: '100%',
      maxWidth: '1200px',
      margin: '0 auto',
      padding: '0 1rem'
    }
  };
export default Layout;