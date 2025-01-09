import React, { useEffect, useState } from "react";
import { getCustomers, deleteCustomer } from "../../services/CustomerService";

function CustomerList({ onCustomerEdit, refresh }) {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        loadCustomers();
    }, [refresh]);

    const loadCustomers = async () => {
        const customers = await getCustomers();
        setCustomers(customers);
    };

    const deleteCustomerHandler = async (id) => {
        try {
            await deleteCustomer(id);
            loadCustomers();
        } catch (error) {
            console.log('Delete failed:', error);
        }
    };

    return (
        <div className="table-responsive">
            <table className="table table-striped table-hover">
                <thead className="table-dark">
                    <tr>
                        <th>#</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Address</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map((customer, index) => (
                        <tr key={customer.id}>
                            <td>{index + 1}</td>
                            <td>{customer.firstName}</td>
                            <td>{customer.lastName}</td>
                            <td>{customer.email}</td>
                            <td>{customer.phoneNumber}</td>
                            <td>{customer.address}</td>
                            <td>
                                <button
                                    className="btn btn-warning btn-sm me-2"
                                    onClick={() => onCustomerEdit(customer)}
                                >
                                    <i className="bi bi-pencil-square me-1"></i>
                                    Edit
                                </button>
                                <button
                                    className="btn btn-danger btn-sm"
                                    onClick={() => deleteCustomerHandler(customer.id)}
                                >
                                    <i className="bi bi-trash me-1"></i>
                                    Delete
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};


export default CustomerList;
