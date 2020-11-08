using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ContactResolver 
{
    
    public static int iterations;
    public static List<ParticleContact> particleContacts = new List<ParticleContact>();

    public static void ResolveContacts(float dt)
    {
        for (int iterationsUsed = 0; iterationsUsed < iterations; iterationsUsed++)
        {
            float max = float.MaxValue;
            int numContacts = particleContacts.Count;
            ParticleContact maxContact = null;

            foreach(ParticleContact contact in particleContacts)
            {
                float sepVel = contact.CalculateSeparatingVel();
                if(sepVel < max && (sepVel < 0.0f || contact.GetPenetration() > 0.0f))
                {
                    max = sepVel;
                    maxContact = contact;
                }

            }

            if(maxContact == null)
            {
                break;
            }

            maxContact.Resolve(dt);
            
            foreach( ParticleContact contact in particleContacts)
            {
                if(contact.GetOBJOne() == maxContact.GetOBJOne())
                {
                    contact.SetPen(contact.GetPenetration() - Vector2.Dot(maxContact.GetMoveOne(), contact.GetContactNormal()));
                }
                else if(contact.GetOBJOne() == maxContact.GetOBJTwo())
                {
                    contact.SetPen(contact.GetPenetration() - Vector2.Dot(maxContact.GetMoveTwo(), contact.GetContactNormal()));
                }

                if (contact.GetOBJTwo())
                {
                    if(contact.GetOBJTwo() == maxContact.GetOBJOne())
                    {
                        contact.SetPen(contact.GetPenetration() + Vector2.Dot(maxContact.GetMoveOne(), contact.GetContactNormal()));
                    }
                    else if(contact.GetOBJTwo() == maxContact.GetOBJTwo())
                    {
                        contact.SetPen(contact.GetPenetration() - Vector2.Dot(maxContact.GetMoveTwo(), contact.GetContactNormal()));
                    }
                }
            }
        }

        particleContacts.Clear();
    }

}
