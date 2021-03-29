import React, { Fragment, useState, useEffect } from 'react'
import { Form, Button } from 'react-bootstrap'

import { useForm } from 'react-hook-form'

import Header from './Header'
import { getAddition } from './services/sensor.service'

const Add = (props) => {

    const { register, handleSubmit, formState, setValue, errors } = useForm({mode:'onChange'});

    useEffect(()=> {
        console.log('Initialized dorsavi code challenge frontent')


        register(
            {name:"numberA"}, {required: { value:true, message:"Number A is required"}, pattern: {value: /\b(?<!\.)\d+(?!\.)\b/, message: "Must be an integer"} })
        register(
            {name:"numberB"}, {required: { value:true, message:"Number B is required"}, pattern: {value: /\b(?<!\.)\d+(?!\.)\b/, message: "Must be an integer"} })
        
        setValue("numberA", numbers.numberA, { shouldValidate:true})        
        setValue("numberB", numbers.numberB, { shouldValidate:true})      
        
      }, [])
    
    const [ result, setResult ] = useState()

    const [ numbers, setNumbers ] = useState({ numberA:null, numberB:null})
    
    const addNumbers = (e) => {
        e.preventDefault();
        
        getAddition(numbers.numberA, numbers.numberB)
        .then(response=>{
            console.log(response)
            setResult(response)
        })
        .catch(err=>console.log(err))
    }

    const updateNumber = (e) => {
        let v = e.target.value

        if (!v)
            v = null

        setValue(e.target.name, v, {shouldValidate:true})
        setNumbers({...numbers, [e.target.name]: v})
    }


    return (
        <Header>
            <Form onSubmit={addNumbers}>
                <Form.Group controlId="numberA">
                    <Form.Label>integer a</Form.Label>
                    <Form.Control name="numberA" type="integer" place="enter a number" value={numbers.numberA} onChange={updateNumber} error={errors.NumberA ? true : false}></Form.Control>
                    <label style={{"color":"red"}}>{formState.errors.numberA && formState.errors.numberA.message}</label>
                </Form.Group>

                <Form.Group controlId="numberB">
                    <Form.Label>integer b</Form.Label>
                    <Form.Control name="numberB" type="integer" place="enter a number" value={numbers.numberB} onChange={updateNumber} error={errors.NumberB ? true : false}></Form.Control>
                    <label style={{"color":"red"}}>{formState.errors.numberB && formState.errors.numberB.message}</label>
                </Form.Group>

                <Button variant="primary" type="submit" disabled={!formState.isValid}>
                    Add numbers
                </Button>
                
                {result && <Fragment><hr /> <h1>The result of the addition is {result}</h1></Fragment>}

            </Form>
        </Header>
        
    )
}

export default Add