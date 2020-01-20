import React from 'react';

const Error = (props) => <div className='error-wrapper'>
    {props.message && <label className='error'>{props.message}</label>}
</div>
export default Error;