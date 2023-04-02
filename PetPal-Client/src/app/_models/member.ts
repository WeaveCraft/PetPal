import { Animal } from './animal';
import { Photo } from './photo';

export interface Member {
    id: number;
    username: string;
    knownAs: string;
    gender: string;
    age: number;
    dateOfBirth: Date;
    created: Date;
    lastActive: Date;
    introduction: string;
    lookingFor: string;
    city: string;
    country: number;
    language: number;
    animals: Animal[];
    photoUrl: string;
    photos: Photo[];
}