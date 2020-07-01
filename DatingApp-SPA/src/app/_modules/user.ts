import { photo } from './Photo';

export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photosUrl: string;
    city: string;
    country: string;
    interests?: string;
    photoUrl?: string;
    introduction?: string;
    lookingFor?: string;
    photos?: photo[];
}
