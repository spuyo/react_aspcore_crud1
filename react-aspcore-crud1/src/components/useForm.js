import React, {useState, useEffect} from "react";
const useForm = (initialFieldValues, validate, setCurrentId) => {
    const [values, setValues] = useState(initialFieldValues)
    const [errors, setErrors] = useState({})
    
    const handleInputChange = e => {
        const {name, value} = e.target
        const fieldValue = {[name]: value}
        setValues({
            ...values,
            ...fieldValue
        })
        validate(fieldValue)
    }
    
    const resetForm = () => {
        setValues({
            ...initialFieldValues
        })
        setErrors({})// clear all errors
        setCurrentId(0) // reset form
    }
    return {
        values,
        setValues,
        errors,
        setErrors,
        resetForm,
        handleInputChange
    }
}

export default useForm;