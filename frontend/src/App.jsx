
import './App.css'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // BrowserRouter, Route ve Switch bileşenlerini import ettik
import 'bootstrap/dist/css/bootstrap.min.css';

import HomePage from './pages/HomePage/HomePage';
import CustomerPage from './pages/Customer/CustomerPage';
import Layout from './components/Layout/Layout';
function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<HomePage />} />  {/* Anasayfa için Route */}
          <Route path="/customers" element={<CustomerPage />} />
        </Routes>
      </Layout>
    </Router>
  )
}

export default App
