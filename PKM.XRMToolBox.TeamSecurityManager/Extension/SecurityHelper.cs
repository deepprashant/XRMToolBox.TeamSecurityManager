using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKM.XRMToolBox.TeamSecurityManager.Extension
{
    public static class SecurityHelper
    {
        public static EntityCollection GetSecurityRole(this IOrganizationService orgService, Guid businessUnitId = default(Guid))
        {
            string[] excludeRoles = new string[] { "Support User" };
            QueryExpression query = new QueryExpression("role");
            query.ColumnSet.AddColumns("roleid", "name", "businessunitid");
            query.Criteria.AddCondition(new ConditionExpression("name", ConditionOperator.NotIn, excludeRoles));
            if (businessUnitId != null && businessUnitId != Guid.Empty)
            {
                query.Criteria.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, businessUnitId));
            }

            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUsers(this IOrganizationService orgService, Guid businessUnitId = default(Guid))
        {
            QueryExpression query = new QueryExpression("systemuser");
            query.ColumnSet.AddColumns("systemuserid", "fullname", "businessunitid", "domainname", "firstname", "lastname", "title", "internalemailaddress", "accessmode");
            query.Criteria.AddCondition(new ConditionExpression("isdisabled", ConditionOperator.Equal, false));
            query.Criteria.AddCondition(new ConditionExpression("accessmode", ConditionOperator.NotEqual, 3));
            query.Criteria.AddCondition(new ConditionExpression("accessmode", ConditionOperator.NotEqual, 5));
            if (businessUnitId != null && businessUnitId != Guid.Empty)
            {
                query.Criteria.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, businessUnitId));
            }

            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetTeams(this IOrganizationService orgService, Guid businessUnitId = default(Guid))
        {
            QueryExpression query = new QueryExpression("team");
            query.ColumnSet.AddColumns("teamid", "name", "businessunitid", "isdefault", "teamtype");
            query.Criteria.AddCondition(new ConditionExpression("teamtype", ConditionOperator.Equal, 0));            
            query.Criteria.AddCondition(new ConditionExpression("systemmanaged", ConditionOperator.Equal, false));
            if (businessUnitId != null && businessUnitId != Guid.Empty)
            {
                query.Criteria.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, businessUnitId));
            }

            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetBusinessUnits(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("businessunit");
            query.ColumnSet.AddColumns("name", "businessunitid", "parentbusinessunitid");
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserRole(this IOrganizationService orgService, List<Guid> userIds = null)
        {           
            QueryExpression query = new QueryExpression("systemuserroles");            
            if (userIds != null)
            {
                query.Criteria.AddCondition(new ConditionExpression("systemuserid", ConditionOperator.In, userIds));
            }

            query.ColumnSet.AddColumns("roleid", "systemuserid");
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserTeam(this IOrganizationService orgService, List<Guid> userIds = null)
        {
            QueryExpression query = new QueryExpression("teammembership");
            if (userIds != null)
            {
                query.Criteria.AddCondition(new ConditionExpression("systemuserid", ConditionOperator.In, userIds));
            }

            query.ColumnSet.AddColumns("systemuserid", "teamid");
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetTeamRole(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("teamroles");
            query.ColumnSet.AddColumns("teamid", "roleid");
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetFieldSecurityProfiles(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("fieldsecurityprofile");
            query.ColumnSet.AddColumns("name");
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetTeamFieldSecurityProfile(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("teamprofiles");
            query.ColumnSet.AddColumns("teamid", "fieldsecurityprofileid");
            return orgService.FetchAllRecords(query);
        }

        public static PrivilegeDepth GetDepth(int depth)
        {
            switch (depth)
            {
                case 2:
                    return PrivilegeDepth.Local;
                case 4:
                    return PrivilegeDepth.Deep;
                case 8:
                    return PrivilegeDepth.Global;
                default:
                    return PrivilegeDepth.Basic;
            }
        }

        private static EntityCollection FetchAllRecords(this IOrganizationService orgService, QueryExpression query)
        {
            List<Entity> records = new List<Entity>();
            query.PageInfo = new PagingInfo();
            query.PageInfo.PageNumber = 1;

            while (true)
            {
                var returnCollections = orgService.RetrieveMultiple(query);
                if (returnCollections.Entities.Count >= 1)
                {
                    records.AddRange(returnCollections.Entities);
                }

                if (returnCollections.MoreRecords)
                {
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = returnCollections.PagingCookie;
                }
                else
                {
                    break;
                }
            }

            EntityCollection data = new EntityCollection(records);
            return data;
        }
    }
}
