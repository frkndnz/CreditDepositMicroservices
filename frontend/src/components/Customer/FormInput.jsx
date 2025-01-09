import React from 'react';

export const FormInput = ({ label, name, type = "text", value, onChange, error, ...props }) => {
  return (
    <div className="mb-3">
      <label className="form-label">{label}</label>
      {type === "textarea" ? (
        <textarea
          className={`form-control ${error ? 'is-invalid' : ''}`}
          name={name}
          value={value}
          onChange={onChange}
          {...props}
        />
      ) : (
        <input
          type={type}
          className={`form-control ${error ? 'is-invalid' : ''}`}
          name={name}
          value={value}
          onChange={onChange}
          {...props}
        />
      )}
      {error && <div className="invalid-feedback">{error}</div>}
    </div>
  );
};