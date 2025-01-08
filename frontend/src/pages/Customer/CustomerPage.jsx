import React, { useState } from 'react';
import CustomerList from '../../components/Customer/CustomerList';

function CustomerPage() {
  return (
   
      <div className="container text-center mt-4">
        <h1>Customer Management</h1>
        <div className='w-100'>

        <CustomerList />
        </div>
      </div>
    
  );
}
export default CustomerPage;