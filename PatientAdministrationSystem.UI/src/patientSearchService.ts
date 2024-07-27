const API_LOCAL_BASE_URL = import.meta.env.VITE_API_LOCAL_BASE_URL;
const API_REMOTE_BASE_URL = import.meta.env.VITE_API_REMOTE_BASE_URL;

export async function searchPatients(query: string): Promise<any[]> {
    const apiUrls = [
        `${API_LOCAL_BASE_URL}/patients/search`,
        `${API_REMOTE_BASE_URL}/patients/search`,
    ];

    for (const url of apiUrls) {
        try {
            const response = await fetch(`${url}?query=${query}`);
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            return data.$values || [];
        } catch (error) {
            console.error(`Failed to fetch from ${url}:`, error);
        }
    }
    return [];
}