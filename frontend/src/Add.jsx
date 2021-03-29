import React, { Fragment, useState, useEffect } from 'react'
import { Form, Button } from 'react-bootstrap'

import Header from './Header'
import { getAddition } from './services/sensor.service'

const Add = (props) => {

    useEffect(()=> {
        console.log('Initialized dorsavi code challenge frontent')
      }, [])
    
    const [ result, setResult ] = useState()

    const [ numbers, setNumbers ] = useState({ numberA:0, numberB:0})
    
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
        setNumbers({...numbers, [e.target.name]: e.target.value})
    }
    
    return (
        <Header>
            <Form onSubmit={addNumbers}>
                <Form.Group controlId="numberA">
                    <Form.Label>integer a</Form.Label>
                    <Form.Control name="numberA" type="integer" place="enter a number" value={numbers.numberA} onChange={updateNumber}></Form.Control>
                </Form.Group>

                <Form.Group controlId="numberB">
                    <Form.Label>integer b</Form.Label>
                    <Form.Control name="numberB" type="integer" place="enter a number" value={numbers.numberB} onChange={updateNumber}></Form.Control>
                </Form.Group>

                <Button variant="primary" type="submit">
                    Add numbers
                </Button>

                
                {result && <Fragment><hr /> <h1>The result of the addition is -> {result}</h1></Fragment>}

            </Form>
        </Header>
        
    )
}

export default Add