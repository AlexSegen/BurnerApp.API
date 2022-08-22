CREATE OR REPLACE FUNCTION public.fn_get_users()
 RETURNS json
 LANGUAGE sql
AS $function$

	select json_agg(output) from(
	
	select 
		*
	from 
		users
		
 ) as output;

$function$
;
