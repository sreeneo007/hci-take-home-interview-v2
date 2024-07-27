import React from 'react';
import { render } from '@testing-library/react';
import '@testing-library/jest-dom';
import SearchResultView from '../SearchResultView';
import { Patient } from '../../interfaces';

const mockPatients: Patient[] = [
    {
        id: '1',
        firstName: 'John',
        lastName: 'Sweeney',
        email: 'john.sweeney@hci.care.com',
        patientHospitals: {
            $values: [
                {
                    hospital: { name: 'Hospital A' },
                    visit: { date: '2023-07-25T00:00:00Z' }
                },
                {
                    hospital: { name: 'Hospital B' },
                    visit: { date: '2023-07-26T00:00:00Z' }
                }
            ]
        }
    },
    {
        id: '2',
        firstName: 'Vinny',
        lastName: 'Lawlor',
        email: 'vinny.lawlor@hci.care.com',
        patientHospitals: { $values: [] }
    }
];

describe('SearchResultView', () => {
    test('renders search results correctly', () => {
        const { getByText, queryByText } = render(<SearchResultView results={mockPatients} />);

        expect(getByText(/Search Results/i)).toBeInTheDocument();
        expect(getByText(/John sweeney/i)).toBeInTheDocument();
        expect(getByText(/vinny.lawlor@hci.care.com/i)).toBeInTheDocument();
        expect(queryByText(/No visit/i)).toBeInTheDocument();
    });

    test('renders no results when empty array is passed', () => {
        const { queryByText } = render(<SearchResultView results={[]} />);
        expect(queryByText(/Search Results/i)).toBeNull();
    });
});