import React, { useState } from 'react';
import Header from './components/Header';
import PatientSearchBar from './components/PatientSearchBar';
import SearchResultView from './components/SearchResultView';
import { searchPatients } from './patientSearchService';
import { Patient } from './interfaces';
import './App.css';
const App: React.FC = () => {
    const [results, setResults] = useState<Patient[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    const handleSearch = async (query: string) => {
        if (!query) {
            setResults([]);
            setError('Search cannot be empty. Please enter valid patient details to search.');
            return;
        }

        setLoading(true);
        setError(null);
        try {
            const data = await searchPatients(query);
            if (data.length === 0) {
                setError('No visit information found.');
            }
            setResults(data);
        } catch (err) {
            setError('Failed to fetch patient data');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <Header />
            <PatientSearchBar onSearch={handleSearch} />
            {loading && <p>Loading...</p>}
            {error && <p className="no-results">{error}</p>}
            {!error && <SearchResultView results={results} />}
        </div>
    );
};

export default App;