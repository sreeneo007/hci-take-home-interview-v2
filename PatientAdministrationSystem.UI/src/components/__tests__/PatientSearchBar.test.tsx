import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import PatientSearchBar from '../PatientSearchBar';

describe('PatientSearchBar', () => {
    test('renders search bar and performs search', () => {
        const onSearchMock = jest.fn();

        render(<PatientSearchBar onSearch={onSearchMock} />);

        const input = screen.getByPlaceholderText(/Enter patient details/i);
        const button = screen.getByText(/Search/i);

     
        fireEvent.change(input, { target: { value: 'John Sweeney' } });   // Simulate user input
        fireEvent.click(button);

        expect(onSearchMock).toHaveBeenCalledWith('John Sweeney');
        expect(screen.queryByText(/Search cannot be empty/i)).toBeNull();
    });

    test('shows error message for empty search', () => {
        render(<PatientSearchBar onSearch={jest.fn()} />);

        const button = screen.getByText(/Search/i);

       
        fireEvent.click(button); // Click search button without entering input

        expect(screen.getByText(/Search cannot be empty/i)).toBeInTheDocument();
    });

    test('clears error message on valid input', () => {
        render(<PatientSearchBar onSearch={jest.fn()} />);

        const input = screen.getByPlaceholderText(/Enter patient details/i);
        const button = screen.getByText(/Search/i);

       
        fireEvent.click(button); // Click search button to show error
        expect(screen.getByText(/Search cannot be empty/i)).toBeInTheDocument();

        
        fireEvent.change(input, { target: { value: 'John Sweeney' } });// Simulate user input
        fireEvent.click(button);

        expect(screen.queryByText(/Search cannot be empty/i)).toBeNull();
    });
});