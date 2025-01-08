import React from "react";


function HomePage() {
    return (

        
            <div className="main-content mt-3" style={styles.mainContent} >
                <h1>Welcome to the Homepage</h1>
                <p>This is the main content area. Add your content here!</p>
            </div>
       


    );
};

const styles = {
    mainContent: {
        display: "flex",
        alignItems: "center",
        height: "100vh",
        flexDirection: "column",
    },
}

export default HomePage;