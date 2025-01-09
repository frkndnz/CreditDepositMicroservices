import React, { useState } from 'react';
import CustomerList from '../../components/Customer/CustomerList';
import CustomerForm from '../../components/Customer/CustomerForm';
import { Modal, Button } from 'react-bootstrap';

function CustomerPage() {

  const [showModal, setShowModal] = useState(false);
  const[refresh, setRefresh] = useState(false);

  const handleSuccess = () => {
    setShowModal(false);
    setRefresh(!refresh);
  }

  return (

    <div className="container text-center mt-4">
      <div className='d-flex justify-content-between align-items-center mb-4'>
        <h1>Customer Management</h1>
        <Button variant="primary" onClick={() => setShowModal(true)}>Add Customer</Button>
      </div>
      {/* CustomerList */}
      <div className='w-100'>
        <CustomerList refresh={refresh} />
      </div>

      <Modal show={showModal} onHide={() => setShowModal(false)} size="lg">
        <Modal.Header closeButton>
          <Modal.Title>Add New Customer</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <CustomerForm onSuccess={handleSuccess} />
        </Modal.Body>
      </Modal>
    </div>

  );
}
export default CustomerPage;