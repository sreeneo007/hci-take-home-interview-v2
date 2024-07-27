export interface Visit {
    date: string;
}

export interface Hospital {
    name: string;
}

export interface PatientHospitalRelation {
    hospital: Hospital;
    visit?: Visit;
}

export interface Patient {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    patientHospitals?: {
        $values?: PatientHospitalRelation[];
    };
}