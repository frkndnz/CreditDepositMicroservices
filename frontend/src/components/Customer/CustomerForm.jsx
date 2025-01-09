import React, { useState } from 'react';
import { addCustomer } from '../../services/CustomerService';
import { Alert } from 'react-bootstrap';
import { FormInput } from './FormInput';
function CustomerForm({ onSuccess }) {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        dateOfBirth: '',
        address: '',
        nationalId: ''
    });
    const [errors, setErrors] = useState({});
    const [apiError, setApiError] = useState('');

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            setErrors({});
            setApiError('');

            const response = await addCustomer(formData);
            onSuccess();
            alert('Customer added successfully');

            // Form gönderildikten sonra temizle
            setFormData({
                firstName: '',
                lastName: '',
                email: '',
                phoneNumber: '',
                dateOfBirth: '',
                address: '',
                nationalId: ''
            });
        }
        catch (error) {
            console.error('Add customer failed:', error);
            if (error.response?.data?.errors) {
                const validationErrors = {};
                error.response.data.errors.forEach(error => {
                    const fieldName = error.field.charAt(0).toLowerCase() + error.field.slice(1);
                    validationErrors[fieldName] = error.message;
                });
                setErrors(validationErrors);

                setApiError("please check the form for errors");
            }
            else {

                setApiError(error.response?.data || 'Something went wrong');
            }
        }
    };

    return (
        <div className="container mt-4">
            <div className="row justify-content-center">
                <div className="col-md-8">
                    <div className="card">
                        <div className="card-header bg-primary text-white">
                            <h3 className="mb-0">Add New Customer</h3>
                        </div>
                        <form onSubmit={handleSubmit}>
                            {apiError && (
                                <Alert variant='danger' className='mb-3'>
                                    {apiError}
                                </Alert>
                            )}

                            <div className="row mb-3">
                                <div className="col-md-6">
                                    <FormInput
                                        label="First Name"
                                        name="firstName"
                                        value={formData.firstName}
                                        onChange={handleChange}
                                        error={errors.firstName}
                                        required
                                    />
                                </div>
                                <div className="col-md-6">
                                    <FormInput
                                        label="Last Name"
                                        name="lastName"
                                        value={formData.lastName}
                                        onChange={handleChange}
                                        error={errors.lastName}
                                        required
                                    />
                                </div>
                            </div>

                            <div className="row mb-3">
                                <div className="col-md-6">
                                    <FormInput
                                        label="Email"
                                        type="email"
                                        name="email"
                                        value={formData.email}
                                        onChange={handleChange}
                                        error={errors.email}
                                        required
                                    />
                                </div>
                                <div className="col-md-6">
                                    <FormInput
                                        label="Phone Number"
                                        type="tel"
                                        name="phoneNumber"
                                        value={formData.phoneNumber}
                                        onChange={handleChange}
                                        error={errors.phoneNumber}
                                        required
                                    />
                                </div>
                            </div>

                            <div className="row mb-3">
                                <div className="col-md-6">
                                    <FormInput
                                        label="Date of Birth"
                                        type="date"
                                        name="dateOfBirth"
                                        value={formData.dateOfBirth}
                                        onChange={handleChange}
                                        error={errors.dateOfBirth}
                                        required
                                    />
                                </div>
                                <div className="col-md-6">
                                    <FormInput
                                        label="National ID"
                                        name="nationalId"
                                        value={formData.nationalId}
                                        onChange={handleChange}
                                        error={errors.nationalId}
                                        required
                                    />
                                </div>
                            </div>

                            <FormInput
                                label="Address"
                                type="textarea"
                                name="address"
                                value={formData.address}
                                onChange={handleChange}
                                error={errors.address}
                                rows="3"
                                required
                            />

                            <div className="d-grid gap-2">
                                <button type="submit" className="btn btn-primary">
                                    Add Customer
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default CustomerForm;