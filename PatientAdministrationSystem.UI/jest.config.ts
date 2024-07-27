import type { Config } from '@jest/types';

const config: Config.InitialOptions = {
    testEnvironment: 'jest-environment-jsdom',
    transform: {
        '^.+\\.tsx?$': 'ts-jest',
    },
    setupFilesAfterEnv: ['<rootDir>/src/setupTests.ts'], 
    moduleNameMapper: {
        '\\.(css|less)$': '<rootDir>/src/__mocks__/styleMock.ts',
    },
};

export default config;