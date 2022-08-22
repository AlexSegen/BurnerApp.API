CREATE OR REPLACE FUNCTION public.fn_delete_user_by_id(userid integer)
 RETURNS TABLE(issuccessful boolean)
 LANGUAGE plpgsql
AS $function$
DECLARE
   deleted_id integer; 
begin
	
  delete from users where id = userid
    returning id into deleted_id;
    -- if this query does not delete any record, so variable "deleted_id" will be null

    if (deleted_id is not null) then 
        return query 
        select true;
    else 
        return query 
        select false;
    end if;

END;
$function$
;
