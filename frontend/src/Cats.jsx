import React, { Fragment, useState, useEffect } from 'react'

import { FaCat, FaDog } from 'react-icons/fa'

import { Table } from 'react-bootstrap'

import Header from './Header'

import { getOwners } from './services/sensor.service'

import './Cats.scss'

const Cats = (props) => {

    const [ owners, setOwners ] = useState()
    const [ loading, setLoading] = useState(true)

    useEffect(()=> {

        console.log('Loading owners with cats')

        getOwners().then((response)=> {
            setOwners(response)
            setLoading(false)
            console.log(response)
        }).catch(err=> {
            console.log(err)
            setLoading(false)
        })
    }, [])

    if (loading) {
        return <Fragment>
        <Header><h4>Loading owners with pets that are a cat .....</h4></Header>
        </Fragment>
    } else {
        return (
        <Fragment>
            <Header>
                <Table striped borderd hover>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Age</th>
                            <th>Gender</th>
                            <th>Pets</th>
                        </tr>
                    </thead>
                    <tbody>
                        {owners.map((owner, index) => {
                            return (
                            <tr key={index}><td>{owner.name}</td><td>{owner.age}</td><td>{owner.gender}</td>
                            <td>
                                {owner.pets.map((pet, index)=> {
                                    return (
                                        <div className="pet">
                                            {pet.type==="Cat" ? <FaCat size={40} /> : <FaDog size={40} />}
                                            <label>{pet.name}</label>
                                        </div>
                                    )
                                })}
                                </td></tr>)
                        })}
                    </tbody>

                </Table>
            </Header>
        </Fragment>
        )
    }
}

export default Cats