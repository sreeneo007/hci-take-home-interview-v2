import React from 'react';
import './SearchResultView.css';
import { Patient } from '../interfaces';

interface ResultsProps {
    results: Patient[];
}

const SearchResultView: React.FC<ResultsProps> = ({ results }) => {
    if (results.length === 0) {
        return null;
    }

    return (
        <div>
            <h2>Search Results</h2>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Hospital</th>
                        <th>Visit Date</th>
                    </tr>
                </thead>
                <tbody>
                    {results.map((patient) => (
                        <React.Fragment key={patient.id}>
                            {patient.patientHospitals?.$values && patient.patientHospitals.$values.length > 0 ? (
                                patient.patientHospitals.$values.map((relation, index) => (
                                    <tr key={`${patient.id}-${index}`}>
                                        {index === 0 && (
                                            <>
                                                <td rowSpan={patient.patientHospitals?.$values?.length || 1}>
                                                    {patient.firstName} {patient.lastName}
                                                </td>
                                                <td rowSpan={patient.patientHospitals?.$values?.length || 1}>
                                                    {patient.email}
                                                </td>
                                            </>
                                        )}
                                        <td>{relation.hospital.name}</td>
                                        <td>
                                            {relation.visit?.date ? new Date(relation.visit.date).toLocaleDateString() : 'No visit information'}
                                        </td>
                                    </tr>
                                ))
                            ) : (
                                <tr key={patient.id}>
                                    <td>{patient.firstName} {patient.lastName}</td>
                                    <td>{patient.email}</td>
                                    <td colSpan={2}>No visit</td>
                                </tr>
                            )}
                        </React.Fragment>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default SearchResultView;