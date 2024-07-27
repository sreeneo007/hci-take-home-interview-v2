import React, { useState } from 'react';
import './PatientSearchBar.css';

interface SearchBarProps {
    onSearch: (query: string) => void;
}

const PatientSearchBar: React.FC<SearchBarProps> = ({ onSearch }) => {
    const [query, setQuery] = useState('');
    const [error, setError] = useState('');

    const handleSearch = () => {
        if (!query.trim()) {
            setError('Search cannot be empty. Please enter valid patient details to search.');
            return;
        }
        else {
            setError('');
            onSearch(query.trim());
        }
    };

    const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Enter') {
            handleSearch();
        }
    };

    return (
        <div className="search-bar-container">
            <div className="search-bar">
                <input
                    type="text"
                    placeholder="Enter patient details (first name, last name, or email address)"
                    value={query}
                    onChange={(e) => {
                        setQuery(e.target.value);
                        if (e.target.value.trim()) {
                            setError('');
                        }
                    }}
                    onKeyDown={handleKeyDown}
                />
                <button onClick={handleSearch}>Search</button>
            </div>
            {error && <div className="error-message">{error}</div>}
        </div>
    );
};
export default PatientSearchBar;