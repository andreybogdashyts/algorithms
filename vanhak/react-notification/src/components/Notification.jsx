import React from "react";

const Notification = ({type, message, children}) => {
  const types = {
    success: 'success',
    message: 'info',
    caution: 'warning',
    error: 'danger'
  };
  type = types[type] || 'info';
  
  return message ? (
    <div className={`alert alert-${type}`}>
      <p>{message}</p>
      {children}
    </div>
  ) : null;
};

export default Notification;
